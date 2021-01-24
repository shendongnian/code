    public void Selezionato1(object sender, EventArgs e)
	{
		//Something in your GUI will have the id of the libro. Get that id and pull the libro out of the dictionary.
		var id = GetSelectedId();
        //Pull the libro from the dictionary
		var libro = _libros[id];
        //Populate the view
		LblTit.Text = libro.Titolo;
		LblAutore.Text = libro.Autore;
		LblAP.Text = libro.AnnoPubb;
	}
