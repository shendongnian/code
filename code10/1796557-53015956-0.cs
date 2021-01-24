    namespace simpleton
    {
        /// <summary>
        /// Interaction logic for AddNewOE.xaml
        /// </summary>
        public partial class AddNewOE : Window
        {
            //db connection
          simpletonDBEntities _db = new simpletonDBEntities();
          public AddNewOE()
          {
            InitializeComponent();
          }
           private void insertobBtn_Click(object sender, RoutedEventArgs e)
           { 
              TextRange tr = new TextRange(rtbEditor.Document.ContentStart, rtbEditor.Document.ContentEnd);
              MemoryStream ms = new MemoryStream();
              tr.Save(ms, DataFormats.Rtf);
              string rtfText = Encoding.ASCII.GetString(ms.ToArray());
              db_entry newdb_entries = new db_entry()
              {
                ReportDetails = rtfText
              };
              _db.ob_entries.Add(newOb_entries);
              _db.SaveChanges();  
           }
            
        }
