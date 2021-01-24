    public async Task<bool> AddPcGame(string gameTitle, string gamePublisher, string gameId)
            {
                string publisherCollectionPath = "PC/Games/" + gamePublisher;
     
                //Try and get the document and check if it exists
                var document = await db.Collection(publisherCollectionPath).Document(gameId).GetSnapshotAsync();
                if (document.Exists)
                {
                    //document exists, do what you want here...
                    return true;
                }
                 //if it doesn't exist insert it:  
                //create the object to insert
                ClassicGame newGame = new ClassicGame()
                {
                    title = gameTitle,
                    publisher = gamePublisher
                };
                //Notice you have to traverse the tree, going from collection to document.  
                //If you try to jump too far ahead, it doesn't seem to work. 
                //.Document(gameId).SetAsync(newGame), is what set's the document's ID and inserts the data for the document.
                CollectionReference collection = db.Collection("PC");
                var document2 = await collection.Document("Games").Collection(gamePublisher).Document(gameId).SetAsync(newGame);
    
                return true;
            }
