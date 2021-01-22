        {
            //....Assuming: IList<PussyCat> iListOfPussyCats
            List<PussyCat> pussyCats = new List<PussyCats>(iListOfPussyCats);
            DoWork(pussyCats.ConvertAll<ICat>( c => c as ICat);
        }
