	var cemValIsOne = hdnCEMStatus.Value == "1";
	var cemIDIsZeroOrEmpty = hdmCEMID.Value == "" || hdmCEMID.Value == "0";
	if(cemValIsOne || (!cemValIsOne && !cemIDIsZeroOrEmpty))
	{
		 // case 1 code...
	}
	else
	{
		// case 0 true if statement code
	}
