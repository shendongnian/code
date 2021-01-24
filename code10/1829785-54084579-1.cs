        public IList<CellViewModel> Cells
        {
            get
            {
                return new List<CellViewModel>(ServiceLocator.Current.GetAllInstances<CellViewModel>());
            }
        }
