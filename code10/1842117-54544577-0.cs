    var input = "3,246,928-";
		
	double result;
	var o = Double.TryParse(input,  NumberStyles.AllowThousands | NumberStyles.AllowTrailingSign, null, out result);
		
    Console.WriteLine(result);
