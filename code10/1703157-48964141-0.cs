	using (StreamReader sr = new StreamReader(response.GetResponseStream()))
	{
		ResponseString = sr.ReadToEnd();
		JavaScriptSerializer js = new JavaScriptSerializer();
		MyObject obj = (MyObject)js.Deserialize(ResponseString, typeof(MyObject));
		textBox1.Text = ResponseString;
		foreach (var nb in obj.NBest)
		{
			Console.WriteLine(nb.Display);
		}
	}
