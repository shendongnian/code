    string originalText = "Hi my name is Mr. Smith from the USA.";
    string[] topPull = { "", "Mr." };
    string[] bottomPull = { "from", "" };
    string result;
    string[] topPage = originalText.Split(topPull,StringSplitOptions.RemoveEmptyEntries);
    string[] bottomPage = 
    topPage[1].Split(bottomPull,StringSplitOptions.RemoveEmptyEntries);
    result = bottomPage[1];
