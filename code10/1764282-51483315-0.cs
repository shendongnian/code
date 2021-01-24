    [Microsoft.VisualStudio.Utilities.ContentType("text")]
    [Microsoft.VisualStudio.Text.Editor.TextViewRole(Microsoft.VisualStudio.Text.Editor.PredefinedTextViewRoles.Editable)]
    [Export(typeof(IVsTextViewCreationListener))]
    public class Main : IVsTextViewCreationListener
    {
        private IOutliningManager _outliningManager;
        private IVsEditorAdaptersFactoryService _editorAdaptersFactoryService;
        public void VsTextViewCreated(IVsTextView textViewAdapter)
        {
            IComponentModel componentModel = (IComponentModel)ServiceProvider.GlobalProvider.GetService(typeof(SComponentModel));
            if (componentModel != null)
            {
                IOutliningManagerService outliningManagerService = componentModel.GetService<IOutliningManagerService>();
                _editorAdaptersFactoryService = componentModel.GetService<IVsEditorAdaptersFactoryService>();
                if (outliningManagerService != null)
                {
                    if (textViewAdapter != null && _editorAdaptersFactoryService != null)
                    {
                        var textView = _editorAdaptersFactoryService.GetWpfTextView(textViewAdapter);
                        var snapshot = textView.TextSnapshot;
                        var snapshotSpan = new Microsoft.VisualStudio.Text.SnapshotSpan(snapshot, new Microsoft.VisualStudio.Text.Span(0, snapshot.Length));
                        _outliningManager = outliningManagerService.GetOutliningManager(textView);
                        var regions = _outliningManager.GetAllRegions(snapshotSpan);
                        foreach (var reg in regions)
                        {
                            _outliningManager.TryCollapse(reg);
                        }
                    }
                }
            }
        }
    }
