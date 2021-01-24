    public class Subscriber
    {
        public string Name { get; set; }
        public void ReceiveNewsLetter(object sender, NewsletterPublishedEventArgs e)
        {
            MessageBox.Show(e.Newsletter.Content);
        }
    }
