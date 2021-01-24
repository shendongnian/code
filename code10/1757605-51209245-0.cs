	public void evaluate()
	{
		string bookTitle = txtBookTitle.Text;
		string frequency = txtTimesBorrowed.Text;
		int f = Int32.Parse(frequency);
		string[] book = { bookTitle, frequency };
		var lstVBookItems = new ListViewItem(book);
		lstVBooks.Items.Add(lstVBookItems);
		if(lstVFBooks.Items.Count == 0 && lstVLBooks.Items.Count == 0)
		{
			lstVFBooks.Items.Add(lstVBookItems);
			lstVLBooks.Items.Add(lstVBookItems);
			mostF = f;
			leastF = f;
		}
		else if (f > mostF)
		{
			lstVFBooks.Items.Clear();
			lstVFBooks.Items.Add(lstVBookItems);
			mostF = f;
		}
		else if (f == mostF)
		{
			lstVFBooks.Items.Add(lstVBookItems);
			mostF = f;
		}
		else if (f < mostF && f == leastF)
		{
			lstVLBooks.Items.Add(lstVBookItems);
			leastF = f;
		}
		else if (f < mostF)
		{
			lstVLBooks.Items.Clear();
			lstVLBooks.Items.Add(lstVBookItems);
			leastF = f;
		}
	}
