	string[] lines = File.ReadAllLines(@"info.txt"); //original file
	fName = dataGridViewF.Rows[e.RowIndex].Cells[0].Value.ToString();
	lName = dataGridViewF.Rows[e.RowIndex].Cells[1].Value.ToString();
	var iter = lines.Where(line => {
		string[] name = line.Split('-');
		string f = name[0];
		string l = name[1];
		if(f.ToLower().Equals(fName.ToLower()))
			if (l.ToLower().Equals(lName.ToLower()))
			{
				return false;
			}
		return true;
	});
	File.WriteAllLines(@"D:\\newfile.txt", iter.ToArray()); //put them in newfile.txt, don't delete the original one which is info.txt
