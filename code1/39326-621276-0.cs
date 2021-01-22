    foreach (string objectName in this.ObjectNames)
    {
        // Line to jump to when this.MoveToNextObject is true.
        while (this.boolValue)
        {
            // 'continue' would jump to here.
            if (this.MoveToNextObject())
            {
                break;
            }
            this.boolValue = this.ResumeWhileLoop();
        }
    }
