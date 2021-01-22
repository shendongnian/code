    class Books : INotifyPropertyChanged
    {
       private int m_id;
       private string m_author;
       private string m_title;
    
       public int ID { get { return m_id; } set { m_id = value; NotifyPropertyChanged("ID"); } }
       public string Author { get { return m_author; } set { m_author = value; NotifyPropertyChanged("Author"); } }
       public string Title { get { return m_title; } set { m_title = value; NotifyPropertyChanged("Title"); } }
    
    
       public event PropertyChangedEventHandler PropertyChanged;
    
       private void NotifyPropertyChanged(string p)
       {
           if (PropertyChanged != null)
               PropertyChanged(this, new PropertyChangedEventArgs(p));
       }
    }
    
    BindingList<Books> books= new BindingList<Books>();
    
    datagridView.DataSource = books;
