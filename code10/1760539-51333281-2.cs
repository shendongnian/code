    switch (ScreenIndex)
    {
        case 0:
            Debug.Log ("X (should be 0) = " + ScreenIndex);
            //If the user is at screen index 0, then a loop should be querying position 0 only here. If the user is at position 1 then a loop should be 
            //querying position 4 - this is because position 1,2,3 will be queried in 'OnEraseProgressScratch2', 'OnEraseProgressScratch3' and 'OnEraseProgressScratch4'.
            if (UIHandler.GetDynamicCorrectAnswerArray () [ScreenIndex].ToString ().Contains ("Correct"))
            {
                Debug.Log ("Answer 1 is correct");
            }
        break;
        case 1:
            ScreenIndex += 3;
    
            Debug.Log ("X (should be 4) = " + ScreenIndex);
    
            if (UIHandler.GetDynamicCorrectAnswerArray () [ScreenIndex].ToString ().Contains ("Correct"))
            {
                Debug.Log ("Answer 1 is correct");
            }
        break; //... and so on
