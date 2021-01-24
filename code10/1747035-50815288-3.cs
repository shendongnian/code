    using Model;
    using Modules.View.ImportAssistant;
    using Prism.Commands;
    using Prism.Mvvm;
    using Prism.Regions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows.Input;
    using Infrastructure.Interfaces;
    using Modules.Interfaces.ImportAssistant;
    using Infrastructure;
    using Prism.Interactivity.InteractionRequest;
    
    namespace Modules.ViewModel.ImportAssistant
    {
        public class ImportDialogViewModel : BindableBase, IImportDialogViewModel
        {
            public IRegionManager RegionManager { get; set; }
    
            private string _title;
            public string Title
            {
                get { return _title; }
                set
                {
                    SetProperty(ref _title, value, nameof(Title));
                }
            }
            public IView View { get; set; }
    
            public IEnumerable<Data> ImportedData { get; set; }
    
    
    
            private INotification _notification;
            public INotification Notification
            {
                get { return _notification; }
                set
                {
                    var confirmation = value as ImportConfirmation;
                    if (confirmation != null)
                    {
                        //SetProperty(ref _notification, value, nameof(Notification));
                        _notification = confirmation;
                        RaisePropertyChanged(nameof(Notification));
                    }
                }
            }
    
    
            public Action FinishInteraction { get; set; }
    
    
            private bool? _dialogResult;
            public bool? DialogResult
            {
                get { return _dialogResult; }
                set
                {
                    if (_dialogResult != value)
                    {
                        SetProperty(ref _dialogResult, value, nameof(DialogResult));
                    }
                }
            }
    
    
            public ICommand AbortAssistantCommand { get; set; }
            public ICommand NextCommand { get; set; }
            public ICommand PreviousCommand { get; set; }
            public ICommand FinishCommand { get; set; }
    
            public ImportDialogViewModel(IImportDialogView view, IRegionManager r)
            {
                RegionManager = r;
    
                View = view;
                View.ViewModel = this;
    
                InitializeCommands();
            }
    
            private void InitializeCommands()
            {
                AbortAssistantCommand = new DelegateCommand(() => { DialogResult = false; });
    
                NextCommand = new DelegateCommand(() =>
                {
                    var importDialogMainRegion = RegionManager.Regions.FirstOrDefault(r => r.Name == RegionNames.ImportAssistantMain);
                    if (importDialogMainRegion != null)
                    {
                        var firstActiveView = importDialogMainRegion.ActiveViews.FirstOrDefault();
                        string viewType = null;
                        if (firstActiveView is IImportStartView)
                        {
                            viewType = typeof(FileSelectionView).FullName;
                        }
                        else if (firstActiveView is FileSelectionView)
                        {
                            viewType = typeof(DataSelectionView).FullName;
                        }
    
    
                        if (string.IsNullOrEmpty(viewType) == false)
                        {
                            RegionManager?.RequestNavigate(RegionNames.ImportAssistantMain, viewType); 
                        }
                    }
                });
    
                PreviousCommand = new DelegateCommand(() =>
                {
                    var importDialogMainRegion = RegionManager.Regions.FirstOrDefault(r => r.Name == RegionNames.ImportAssistantMain);
                    if (importDialogMainRegion != null)
                    {
                        var firstActiveView = importDialogMainRegion.ActiveViews.FirstOrDefault();
    
                    }
                });
    
                FinishCommand = new DelegateCommand(() => 
                {
                    DialogResult = true;
                    FinishInteraction?.Invoke();
                });
            }
    
            
        }
    }
    
