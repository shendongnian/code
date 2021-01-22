    public static void RobustMove(string sourceDirectory, string destDirectory)
    {
        //move if directories are on the same volume
        if (Path.GetPathRoot(source) == Path.GetPathRoot(destination))
        {
            Directory.Move(source, destination);
        }
        else
        {        
            CopyDirectoryRecursive(source, destination);
            Directory.Delete(source, true);
        }
    }
