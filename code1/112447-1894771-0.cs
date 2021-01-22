    if(fileVersion ==1)
    { 
        serializedProject = Migrate1to2(serializedProject);
        fileVersion = 2;
    }
    if(fileVersion ==2)
    { 
        serializedProject = Migrate2to3(serializedProject);
        fileVersion = 3;
    }
    if(fileVersion ==3)
    { 
        serializedProject = Migrate3to4(serializedProject);
        fileVersion = 4
    }
    else 
    {
         //could not migrate project message
         return null;
    }
