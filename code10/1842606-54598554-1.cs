    public partial class ListPresentationView
    {
        Storyboard sbPrompt;
        Storyboard sbTarget;
        bool _isCompSleep = false;
        List<int> _completedListViewIndices = new List<int>();
        public ListPresentationView()
        {
            InitializeComponent();
            DataContext = new ListPresentationViewModel();
            // Needed for controlling storyboards
            NameScope.SetNameScope(this, new NameScope());
        }
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            RegisterElementsInNameScope();
            AnimateCurrentItem(0);
        }
        private void RegisterElementsInNameScope()
        {
            var gen = listViewCombined.ItemContainerGenerator;
            var obj = (gen.ContainerFromItem(listViewCombined.Items[0]));
            if (obj != null)
            {
                ListViewItem myListBoxItem = (ListViewItem)obj;
                ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(myListBoxItem);
                DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;
                Image promptImage = (Image)myDataTemplate.FindName("PromptImage", myContentPresenter);
                Image targetImage = (Image)myDataTemplate.FindName("TargetImage", myContentPresenter);
                this.RegisterName(listViewCombined.Name, listViewCombined);
                this.RegisterName(promptImage.Name, promptImage);
                this.RegisterName(targetImage.Name, targetImage);
            }
        }
        private void AnimateCurrentItem(int currIndex)
        {
            Console.WriteLine("AnimateCurreintItem, currIndex: " + currIndex);
            var gen = listViewCombined.ItemContainerGenerator;
            var obj = (gen.ContainerFromItem(listViewCombined.Items[currIndex]));
            if (obj != null)
            {
                ListViewItem myListBoxItem = (ListViewItem)obj;
                ContentPresenter myContentPresenter = FindVisualChild<ContentPresenter>(myListBoxItem);
                DataTemplate myDataTemplate = myContentPresenter.ContentTemplate;
                Image promptImage = (Image)myDataTemplate.FindName("PromptImage", myContentPresenter);
                Image targetImage = (Image)myDataTemplate.FindName("TargetImage", myContentPresenter);
                this.UnregisterName(listViewCombined.Name);
                this.UnregisterName(promptImage.Name);
                this.UnregisterName(targetImage.Name);
                this.RegisterName(listViewCombined.Name, listViewCombined);
                this.RegisterName(promptImage.Name, promptImage);
                this.RegisterName(targetImage.Name, targetImage);
                DoubleAnimation promptAni = new DoubleAnimation();
                promptAni.From = 1;
                promptAni.To = 0;
                promptAni.Duration = new Duration(TimeSpan.FromMilliseconds(4000));
                sbPrompt = new Storyboard();
                sbPrompt.Children.Add(promptAni);
                Storyboard.SetTargetName(promptAni, promptImage.Name);
                Storyboard.SetTargetProperty(promptAni, new PropertyPath(Image.OpacityProperty));
                DoubleAnimationUsingKeyFrames targetAni = new DoubleAnimationUsingKeyFrames();
                var kf1 = new DiscreteDoubleKeyFrame(0.25, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(0)));
                var kf2 = new DiscreteDoubleKeyFrame(1, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(2)));
                var kf3 = new DiscreteDoubleKeyFrame(0.25, KeyTime.FromTimeSpan(TimeSpan.FromSeconds(4)));
                targetAni.KeyFrames.Add(kf1);
                targetAni.KeyFrames.Add(kf2);
                targetAni.KeyFrames.Add(kf3);
                if (sbTarget != null) sbTarget.Completed -= Storyboard_Completed_1;
                sbTarget = new Storyboard();
                sbTarget.Completed += Storyboard_Completed_1;
                sbTarget.Children.Add(targetAni);
                Storyboard.SetTargetName(targetAni, targetImage.Name);
                Storyboard.SetTargetProperty(targetAni, new PropertyPath(Image.OpacityProperty));
                sbPrompt.Begin(this, true);
                sbTarget.Begin(this, true);
            }
            else
            {
                ;
            }
        }
        private void listViewCombined_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var lView = sender as ListView;
            if (lView != null)
            {
                var index = lView.SelectedIndex;
                if (index >= 0 && index < lView.Items.Count)
                {
                    AnimateCurrentItem(index);
                }
            }
        }
        private childItem FindVisualChild<childItem>(DependencyObject obj)
            where childItem : DependencyObject
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
            {
                DependencyObject child = VisualTreeHelper.GetChild(obj, i);
                if (child != null && child is childItem)
                    return (childItem)child;
                else
                {
                    childItem childOfChild = FindVisualChild<childItem>(child);
                    if (childOfChild != null)
                        return childOfChild;
                }
            }
            return null;
        }
        private void Storyboard_Completed_1(object sender, EventArgs e)
        {
            Console.WriteLine("Storyboard_Completed_1 " + DateTime.Now.ToString("HH:mm:ss.fff"));
            var vm = this.DataContext as ListPresentationViewModel;
            if (!_isCompSleep) vm.CombinedAnimationCompletedCommand.Execute(null);
        }
        private void SuspendOrResumeStoryboard(PowerModes mode)
        {
            if (mode == PowerModes.Resume || mode == PowerModes.Suspend)
            {
                {
                    try
                    {
                        if (sbPrompt != null && sbTarget != null)
                        {
                            if (mode == PowerModes.Suspend)
                            {
                                _isCompSleep = true;
                                sbPrompt.Pause(this);
                                sbTarget.Pause(this);
                                Console.WriteLine("===PAUSED" + " " + DateTime.Now.ToString("HH:mm:ss.fff"));
                            }
                            else if (mode == PowerModes.Resume)
                            {
                                _isCompSleep = false;
                                sbPrompt.Resume(this);
                                sbTarget.Resume(this);
                                Console.WriteLine("===RESUMED" + " " + DateTime.Now.ToString("HH:mm:ss.fff"));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            SuspendOrResumeStoryboard(PowerModes.Suspend);
        }
        private void Resume_Click(object sender, RoutedEventArgs e)
        {
            SuspendOrResumeStoryboard(PowerModes.Resume);
        }
    }
