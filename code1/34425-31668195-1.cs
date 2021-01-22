        /// <summary>
        /// 1 - Given an array of int, create one OracleParameter for each one and assigin value, unique named using uniqueParName
        /// 2 - Insert the OracleParameter created into the ref list.
        /// 3 - Return a string to be used to concatenate to the main SQL
        /// </summary>
        /// <param name="orclParameters"></param>
        /// <param name="lsIds"></param>
        /// <param name="uniqueParName"></param>
        /// <returns></returns>
        private static string InsertParameters(ref List<OracleParameter> orclParameters, int[] lsIds, string uniqueParName)
        {
            string strParametros = string.Empty;
            for (int i = 0; i <= lsIds.Length -1; i++)
            {
                strParametros += i == 0 ? ":" + uniqueParName + i : ", :" + uniqueParName + i;
                OracleParameter param = new OracleParameter(uniqueParName + i.ToString(), OracleType.Number);
                param.Value = lsIds[i];
                orclParameters.Add(param);
            }
            return strParametros;
        }
