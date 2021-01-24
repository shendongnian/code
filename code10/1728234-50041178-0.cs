    var newPiece = new Piece
    {
        PieceTitle = Title.Text,
        PieceAuthor = Author.Text,
        PieceIsbn = Isbn.Text,
        PieceDescription = Description.Text
    };
    using (var client = new System.Net.Http.HttpClient()) {
        var json = JsonConvert.SerializeObject(newPiece);            
        var content = new System.Net.Http.FormUrlEncodedContent(
            new Dictionary<string, string> {
                ["value"] = json
            });
        await client.PostAsync(App.BaseUri, content);           
    }
