     public class DisplayCard
        {
            public int Score { get; set; }
            public string Name { get; set; }
        }
    List<DisplayCard> ScoreCard = new List<DisplayCard>();
    for (int x = 0; x < gameClass.scorenames.Count(); x++)
                {
                    contains = gameClass.scorenames[x].Split(':');
                    var name = contains[0];
                    var score = Convert.ToInt32(contains[1]);
                    ScoreCard.Add(new DisplayCard { Name = name, Score = score });
                }
    foreach (var card in ScoreCard)
            {
                richTextBox1.Text += card.Name;
                richTextBox2.Text += card.Score;
                /* take care of new line logic*/
            }
