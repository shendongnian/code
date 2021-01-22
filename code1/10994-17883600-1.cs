    public class SelectableVirtualizingTreeView : TreeView {
        public SelectableVirtualizingTreeView() {
            VirtualizingStackPanel.SetIsVirtualizing(this, true);
            VirtualizingStackPanel.SetVirtualizationMode(this, VirtualizationMode.Recycling);
            var panelfactory = new FrameworkElementFactory(typeof(SelectableVirtualizingStackPanel));
            panelfactory.SetValue(Panel.IsItemsHostProperty, true);
            var template = new ItemsPanelTemplate { VisualTree = panelfactory };
            ItemsPanel = template;
        }
        public void BringItemIntoView(ITreeItem treeItemViewModel) {
            if (treeItemViewModel == null) {
                return;
            }
            var stack = new Stack<ITreeItem>();
            stack.Push(treeItemViewModel);
            while (treeItemViewModel.Parent != null) {
                stack.Push(treeItemViewModel.Parent);
                treeItemViewModel = treeItemViewModel.Parent;
            }
            ItemsControl containerControl = this;
            while (stack.Count > 0) {
                var viewModel = stack.Pop();
                var treeViewItem = containerControl.ItemContainerGenerator.ContainerFromItem(viewModel);
                var virtualizingPanel = FindVisualChild<SelectableVirtualizingStackPanel>(containerControl);
                if (virtualizingPanel != null) {
                    var index = viewModel.Parent != null ? viewModel.Parent.Children.IndexOf(viewModel) : Items.IndexOf(treeViewItem);
                    virtualizingPanel.BringIntoView(index);
                    Focus();
                }
                containerControl = (ItemsControl)treeViewItem;
            }
        }
        
        protected override DependencyObject GetContainerForItemOverride() {
            return new SelectableVirtualizingTreeViewItem();
        }
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item) {
            base.PrepareContainerForItemOverride(element, item);
            ((TreeViewItem)element).IsExpanded = true;
        }
        private static T FindVisualChild<T>(Visual visual) where T : Visual {
            for (var i = 0; i < VisualTreeHelper.GetChildrenCount(visual); i++) {
                var child = (Visual)VisualTreeHelper.GetChild(visual, i);
                if (child == null) {
                    continue;
                }
                var correctlyTyped = child as T;
                if (correctlyTyped != null) {
                    return correctlyTyped;
                }
                var descendent = FindVisualChild<T>(child);
                if (descendent != null) {
                    return descendent;
                }
            }
            return null;
        }
    }
	
    public class SelectableVirtualizingTreeViewItem : TreeViewItem {
        public SelectableVirtualizingTreeViewItem() {
            var panelfactory = new FrameworkElementFactory(typeof(SelectableVirtualizingStackPanel));
            panelfactory.SetValue(Panel.IsItemsHostProperty, true);
            var template = new ItemsPanelTemplate { VisualTree = panelfactory };
            ItemsPanel = template;
            SetBinding(IsSelectedProperty, new Binding("IsSelected"));
            SetBinding(IsExpandedProperty, new Binding("IsExpanded"));
        }
        protected override DependencyObject GetContainerForItemOverride() {
            return new SelectableVirtualizingTreeViewItem();
        }
        protected override void PrepareContainerForItemOverride(DependencyObject element, object item) {
            base.PrepareContainerForItemOverride(element, item);
            ((TreeViewItem)element).IsExpanded = true;
        }
    }
    public class SelectableVirtualizingStackPanel : VirtualizingStackPanel {
        public void BringIntoView(int index) {
            if (index < 0) {
                return;
            }
            BringIndexIntoView(index);
        }
    }
    public abstract class TreeItemBase : ITreeItem {
        protected TreeItemBase() {
            Children = new ObservableCollection<ITreeItem>();
        }
        public ITreeItem Parent { get; protected set; }
        public IList<ITreeItem> Children { get; protected set; }
        
        public abstract bool IsSelected { get; set; }
        
        public abstract bool IsExpanded { get; set; }
        public event EventHandler DescendantSelected;
        protected void RaiseDescendantSelected(TreeItemViewModel newItem) {
            if (Parent != null) {
                ((TreeItemViewModel)Parent).RaiseDescendantSelected(newItem);
            } else {
                var handler = DescendantSelected;
                if (handler != null) {
                    handler.Invoke(newItem, EventArgs.Empty);
                }
            }
        }
    }
	
    public class MainViewModel : INotifyPropertyChanged {
        private TreeItemViewModel _selectedItem;
        public MainViewModel() {
            TreeItemViewModels = new List<TreeItemViewModel> { new TreeItemViewModel { Name = "Item" } };
            for (var i = 0; i < 30; i++) {
                TreeItemViewModels[0].AddChildInitial();
            }
            TreeItemViewModels[0].IsSelected = true;
            TreeItemViewModels[0].DescendantSelected += OnDescendantSelected;
        }
        public event EventHandler DescendantSelected;
        public event PropertyChangedEventHandler PropertyChanged;
        public List<TreeItemViewModel> TreeItemViewModels { get; private set; }
        public TreeItemViewModel SelectedItem {
            get {
                return _selectedItem;
            }
            set {
                if (_selectedItem == value) {
                    return;
                }
                _selectedItem = value;
                var handler = PropertyChanged;
                if (handler != null) {
                    handler.Invoke(this, new PropertyChangedEventArgs("SelectedItem"));
                }
            }
        }
        private void OnDescendantSelected(object sender, EventArgs eventArgs) {
            var handler = DescendantSelected;
            if (handler != null) {
                handler.Invoke(sender, eventArgs);
            }
        }
    }
    public partial class MainWindow {
        public MainWindow() {
            InitializeComponent();
            var mainViewModel = (MainViewModel)DataContext;
            mainViewModel.DescendantSelected += OnMainViewModelDescendantSelected;
        }
        private void OnAddButtonClick(object sender, RoutedEventArgs e) {
            var mainViewModel = (MainViewModel)DataContext;
            var treeItemViewModel = mainViewModel.SelectedItem;
            if (treeItemViewModel != null) {
                treeItemViewModel.AddChild();
            }
        }
        private void OnMainViewModelDescendantSelected(object sender, EventArgs eventArgs) {
            _treeView.BringItemIntoView(sender as TreeItemViewModel);
        }
        private void OnTreeViewSelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e) {
            if (e.OldValue == e.NewValue) {
                return;
            }
            var treeView = (TreeView)sender;
            var treeItemviewModel = treeView.SelectedItem as TreeItemViewModel;
            var mainViewModel = (MainViewModel)DataContext;
            mainViewModel.SelectedItem = treeItemviewModel;
        }
    }
