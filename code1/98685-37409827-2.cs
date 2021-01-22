            int enumValueInt = 1;
            List<int> enumValueIntList =  typeof(TESTENUM).GetEnumValues().Cast<object>().Select(m =>
                Convert.ToInt32(m)
                ).ToList();
            if(!enumValueIntList.Exists(m => m == enumValueInt))
            {
                throw new Exception("cannot find type");
            }
            TESTENUM testEnumValueConvertInt;
            Enum.TryParse<TESTENUM>(enumValueString, out testEnumValueConvertInt);
