     public partial class Form1 : Form
     {
        public Form1()
        {
            InitializeComponent();
        }
        class Person
        {
            public string Name { get; set; }
            public string Lastname { get; set; }
        }
        private void createNode(string pID, string pName, string pSurname, string pAge, XmlTextWriter writer)
        {
            writer.WriteStartElement("Osoba");
            writer.WriteStartElement("Id");
            writer.WriteString(pID);
            writer.WriteEndElement();
            writer.WriteStartElement("Imie");
            writer.WriteString(pName);
            writer.WriteEndElement();
            writer.WriteStartElement("Nazwisko");
            writer.WriteString(pSurname);
            writer.WriteEndElement();
            writer.WriteStartElement("Wiek");
            writer.WriteString(pAge);
            writer.WriteEndElement();
            writer.WriteEndElement();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string[] Imie = { "Anna", "Piotr", "Katarzyna ", "Andrzej", "Małgorzata", "Jan", "Agnieszka ", "Stanisław", "Barbara", "Tomasz", "Marcin", "Marek", "Magdalena", "Łukasz" };
            string[] Nazwisko = { "Wieczorek", "Stępień", "Pawlak", "Baran", "Wróblewski", "Ostrowski", "Zając", "Adamczyk", "Walczak", "Michalak", "Jaworski" };
            Random losuj = new Random();
            List<Person> list = new List<Person>();
            XmlTextWriter writer = new XmlTextWriter("osoby.xml", System.Text.Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Indentation = 2;
            writer.WriteStartElement("Osoby");
            for (int i = 0; i < 500; i++)
            {
                var name = Imie[losuj.Next(0, 7)];
                var lastname = Nazwisko[losuj.Next(0, 7)];
                var presentInList = list.Where(p => p.Name == name && p.Lastname == lastname).FirstOrDefault();
                if (presentInList == null)
                {
                    list.Add(new Person { Name = name, Lastname = lastname });
                    createNode(i.ToString(), name, lastname, losuj.Next(1, 50).ToString(), writer);
                }
            }
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Close();
            MessageBox.Show("Utworzono plik XML,teraz możesz zapisać plik XML do pliku TXT ! ");
        }
    }
