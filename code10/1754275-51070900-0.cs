		private void Form1_Load(object sender, EventArgs e)
		{
            //this would be replaced with your query results from the database
			string[] input = { "able", "alpha", "baker", "bravo", "charlie", "charcoal", "dog", "delta", "eagle", "foxtrot" };
            List<string> pretendThisCameFromAQuery = new List<string>(input);
            //define an AutoCompleteStringCollection. Notice it is outside of the loop as you want to add to this with each iteration of the read() or in this case the foreach loop i'm using.
			AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
			
            //here is where your While reader.read() would go
            foreach (string item in pretendThisCameFromAQuery)
			{
				collection.Add(item);
                //your code here would be something like
                //collection.Add(reader["Medicine Name"].ToString());
			}
			//so now we have a collection. Who wants to use it.
			//for txtName1, we'll set it up to just suggest.
			txtName1.AutoCompleteCustomSource = collection;
			txtName1.AutoCompleteMode = AutoCompleteMode.Suggest;
			txtName1.AutoCompleteSource = AutoCompleteSource.CustomSource;
			//for textbox2 we'll use suggestappend.
			//notice no new collection needed.
			textBox2.AutoCompleteCustomSource = collection;
			textBox2.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
			textBox2.AutoCompleteSource = AutoCompleteSource.CustomSource;
		}
