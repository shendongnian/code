        catch (ChangeConflictException x)
        {
        DoNothingWith(x);// This suppress the 'x' not used warning
        foreach (ObjectChangeConflict occ in DB.ChangeConflicts)
        {
            occ.Resolve(RefreshMode.KeepChanges);
        }
        }
    
        [Conditional("Debug")]
        public static void DoNothingWith(object obj){
           
        }
