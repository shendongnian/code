    public class PersistenceStatePresenter
    {
        ...
        public Save
        {
            string sFilename;
    
            if (_model.Filename == _model.DefaultName || _model.Filename == null)
            {
                var openDialogPresenter = new OpenDialogPresenter();
                openDialogPresenter.Show();
                if(!openDialogPresenter.Cancel)
                {
                    return; // user canceled the save request.
                }
                else
                    sFilename = openDialogPresenter.FileName;
    
            ...
