    using System.Collections.Generic;
    using Infrastructure.Interfaces;
    using Model;
    using MvvmDialogs;
    using Prism.Interactivity.InteractionRequest;
    using Prism.Regions;
    
    namespace Modules.Interfaces.ImportAssistant
    {
        public interface IImportDialogViewModel : IViewModel, IModalDialogViewModel, IInteractionRequestAware
        {
            IEnumerable<Data> ImportedData { get; set; }
            IRegionManager RegionManager { get; set; }
        }
    }
