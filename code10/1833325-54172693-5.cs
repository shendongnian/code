       for (int i = 0; i< subScribedComponents.Length; i++)
       {
            if (subScribedComponents[i] is IPausable)
           {
                IPausable pauseInterface = subScribedComponents[i] as IPausable;
                pauseInterface .Pause();
            }
        }
