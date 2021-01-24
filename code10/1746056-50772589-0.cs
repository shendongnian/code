		// here is the solution 
            string str = listBox1.Items[0].ToString();
  
            char[] b = new char[str.Length];
 
       using (StringReader sr = new StringReader(str))
            {
                // Read 16 characters from the string into the array.
                sr.Read(b, 0, 16);
		//  to show the result print
                string output = string.Join("", b);
                MessageBox.Show(output);
		//  but what if i want to read from 5 to 9
		// it does not resolve yet!
