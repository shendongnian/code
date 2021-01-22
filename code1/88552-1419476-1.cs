    public partial class Form1 : Form
    {
      CardDealer dealer;
      public Form1()
      {
         InitializeComponent();
         dealer = new CardDealer(timer1);
      }
      private void button1_Click(object sender, EventArgs e)
      {
         dealer.QueueCard(img1, cardImage1);
         dealer.QueueCard(img2, cardImage2);
         dealer.QueueCard(img3, cardImage1);
      }
    }
    class CardDealer
    {
      // A queue of pairs in which the first value represents
      // the slot where the card will go, and the second is
      // a reference to the image that will appear there.
      Queue<KeyValuePair<Label, Image>> cardsToDeal;
      System.Windows.Forms.Timer dealTimer;
      public CardDealer(System.Windows.Forms.Timer dealTimer)
      {
         cardsToDeal = new Queue<KeyValuePair<Label, Image>>();
         dealTimer.Tick += new EventHandler(dealTimer_Tick);
         this.dealTimer = dealTimer;
      }
      void dealTimer_Tick(object sender, EventArgs e)
      {
         KeyValuePair<Label, Image> cardInfo = cardInfo = cardsToDeal.Dequeue();
         cardInfo.Key.Image = cardInfo.Value;
         if (cardsToDeal.Count <= 0)
            dealTimer.Enabled = false;
      }
      public void QueueCard(Label slot, Image card)
      {
         cardsToDeal.Enqueue(new KeyValuePair<Label, Image>(slot, card));
         dealTimer.Enabled = true;
      }
    }
