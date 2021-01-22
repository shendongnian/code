	var bm= new System.Drawing.Bitmap('tif path');
	var total = bm.GetFrameCount(System.Drawing.Imaging.FrameDimension.Page);
	for(var x=0;x<total;x++)
	{
		bm.SelectActiveFrame(System.Drawing.Imaging.FrameDimension.Page,x);
		var img=Image.GetInstance(bm,null,false);
		
		//do what ever you want with img object
	}
