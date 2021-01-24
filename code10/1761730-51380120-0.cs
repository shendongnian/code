		GameObject Apple = ...;//set depeding on color
		GameObject Bannana = ...;//set depeding on color
		GameObject Berry = ...;//set depeding on color
		
		for(int i = 0; i <3;i++)
		{
			GeneratePiece(Apple, 0,i);
		}
		for(int i = 0; i <2;i++)
		{
			GeneratePiece(Bannana, 1,i);
		}
		GeneratePiece(Bannana, 2,0);		
		GeneratePiece(Berry,2,2);
