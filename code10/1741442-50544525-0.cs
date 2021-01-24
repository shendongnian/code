    private void buCompW1W2_Click(object sender, EventArgs e)
    {
                Task t1 = Task.Run(() =>
                {
                    //starts moving card to new position
                    DeckPOne.MoveCardFromTopToTop(WarPOne);
                    DeckPTwo.MoveCardFromTopToTop(WarPTwo);
                    //code I hope to enter to delay next steps
                    Stopwatch stopwatch = Stopwatch.StartNew();
                    while (true)
                    { //AwaitingReceiving indicates is Deck expects to receive card, 0 means, card is already there
                      if (WarPOne.AwaitingRecieving == 0 && WarPTwo.AwaitingRecieving == 0)
                        break;
                    }
                    //this test must be done after cards arrive to new place, else its error (-1)
                    //test compares cards in WarPOne and WarPTwo, but cards are not there yet (cards are waiting for timer tick to change position etc.) so it returns
                    //en error, mechanicaly done it works like intended
                    switch (CompareCards(WarPOne.TopCard, WarPTwo.TopCard))
                    {
                        case -1: tbRecord.Text += "\n error comparing"; break;
                        case 1: tbRecord.Text += "\n P1 won."; break;
                        case 2: tbRecord.Text += "\n P2 won."; break;
                        case 0:
                            {
                                tbRecord.Text += "\n WAR!";
                                for (int i = 0; i < 3; i++)
                                {
                                    DeckPOne.MoveCardFromTopToTop(WarPOne);
                                    DeckPTwo.MoveCardFromTopToTop(WarPTwo);
                                }
                            }; break;
                    }
                });
    }
