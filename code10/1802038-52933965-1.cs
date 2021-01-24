    void SetSail()
    {
        promptText.text = "";
        promptText2.text = "";
        addParents();
        if (whichSide == "sailing" && direction == "toFinish")
        {
            speed = 0.05f;
            gameObject.transform.Translate(speed, 0, 0);
        }
        else if (whichSide == "sailing" && direction == "toStart")
        {
            speed = -0.05f;
            gameObject.transform.Translate(speed, 0, 0);
        }
        else if (whichSide == "start" || whichSide == "finish")
        {
            gameObject.transform.Translate(speed, 0, 0);
            canSail = false; //Adding this line solves the issues, must have been affecting transform properties to child objects.
            removeParents();
        }
    }
