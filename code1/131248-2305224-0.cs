public class FileWrapper: System.ComponentModel.INotifyPropertyChanged{
    private string m_filename;
    public string FileExtension{
        get{ return GetFileExtension(FileName);}
    }
    public string FileName{
        get{ return m_filename;}
        set{ m_filename = value; OnPropertyChanged("FileName"); OnPropertyChanged( "FileExtension");
    }
    public string GetFileExtension( string filename){
        //implementation
    }
    public event System.ComponentModel.NotifyPropertyChangedEvent PropertyChanged = (a,b)=>{};
    protected void OnPropertyChanged(string property){
        PropertyChanged( this, new System.ComponentModel.PropertyChangedEventArgs( property ));
    }
}
