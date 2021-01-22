    public class ViewModelBuilderFactory
    {
        public IViewModelBuilder GetViewModelBuilder (string docType, IRepository repository)
        {
            switch (docType)
            {
                case "ProgressNotes":
                    return new ProgressNotesViewModelBuilder(repository);
                case "Labs":
                    return new LabsViewModelBuilder(repository);
                default:
                    throw new ArgumentException(
                        string.Format("docType \"{0}\" Invalid", docType);
            }
        }
    }
    public interface IViewModelBuilder
    {
        TreeViewModel GetDocTreeViewModel();
        WorkSpace GetWorkSpace(Patient patient);
    }
    public class LabsViewModelBuilder : IViewModelBuilder
    {
        private IRepository _repository;
        public LabsViewModelBuilder(IRepository repository)
        {
            _repository = repository;
        }
        public TreeViewModel GetDocTreeViewModel()
        {
            return new TreeViewModel(_repository.GetPatientLabs());
        }
        public Workspace GetWorkspace(Patient patient)
        {
            return LabViewModel.NewLabViewModel(patient);
        }
    }
    public class ProgressNotesViewModelBuilder : IViewModelBuilder
    {
        private IRepository _repository;
        public ProgressNotesViewModelBuilder(IRepository repository)
        {
            _repository = repository;
        }
        public TreeViewModel GetDocTreeViewModel()
        {
            return new TreeViewModel(_repository.GetPatientProgressNotes());
        }
        public Workspace GetWorkspace(Patient patient)
        {
            return ProgressNoteViewModel.NewProgressNoteViewModel(patient);
        }
    }
