    string originalText = "Hi my name is Mr. Smith from the USA.";
    
    string[] topPull = { "", "Mr." };
    string[] bottomPull = { "from", "" };
    string result;
    string[] topPage = originalText.Split(topPull,StringSplitOptions.RemoveEmptyEntries);
    string[] bottomPage = 
    originalText.Split(bottomPull,StringSplitOptions.RemoveEmptyEntries);
    //topPage[0] gives all text above topPull, but not topPull it's self
    //bottomPull[1] gives all text below bottomPull, but not bottomPull it's self
    //now that we have grabbed all the text above and below our known sections we need to 
    //add in the known sections themselves, ie topPull and bottomPull
    result = topPage[0] + topPull[1] + " " + bottomPull[0] + bottomPage[1];
