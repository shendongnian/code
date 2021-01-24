    float[] samples = { 0.0f, 4.0f, 2.5f, 2.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };
    
    List<float> clean = samples.ToList();
    for(int i=clean.Count-1; i>0; i--)
    {
    	if (clean[i] == 0.0f) clean.RemoveAt(i);
    	else break;
    }
    
    //clean.ToArray()
