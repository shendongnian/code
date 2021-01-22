    public class Window1 : Window {
        public ObservableCollection<ImageSource> MyImageCollection { get; set; }
        ...
        public void blah()
        {
            using( var o = new OpenFileDialog())
            {
                if(o.ShowDialog() == DialogResult.OK)
                {
                    MyImageCollection.Add(new BitmapImage(o.FileName));
                }
            }
        }
    }
