        public static void SetIfSameType<K>(ref K toSet, object val)
            where K : class
        {
            if (val.GetType() == typeof(K))
                toSet = val as K;
        }
        SetIfSameType(ref parsedModel.MSH, header);
        SetIfSameType(ref parsedModel.FAC, header);
        SetIfSameType(ref parsedModel.PRD, header);
        SetIfSameType(ref parsedModel.PID, header);
