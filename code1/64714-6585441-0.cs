        public IList<SearchResultsMember> SearchMembers(int memberID, string countryCode, string regionCode, string cityCode, float distanceKm,
            int genderID, int ageMin, int ageMax, int offsetRowIndex, int maxRows)
        {
            
            MySqlParameter[] queryParams = new MySqlParameter[] { 
                                            new MySqlParameter("memberIDParam", memberID),
                                            new MySqlParameter("countryCodeParam", countryCode),
                                            new MySqlParameter("regionCodeParam", regionCode),
                                            new MySqlParameter("cityCodeParam", cityCode),
                                            new MySqlParameter("distanceKmParam", distanceKm),
                                            new MySqlParameter("genderIDParam", genderID),
                                            new MySqlParameter("ageMinParam", ageMin),
                                            new MySqlParameter("ageMaxParam", ageMax),
                                            new MySqlParameter("offsetRowIndexParam", offsetRowIndex),
                                            new MySqlParameter("maxRowsParam", maxRows)
                                        };
            StringBuilder sb = new StringBuilder();
            sb.Append("CALL search_members(@memberIDParam, @countryCodeParam, @regionCodeParam, @cityCodeParam, @distanceKmParam, @genderIDParam, @ageMinParam, @ageMaxParam, @offsetRowIndexParam, @maxRowsParam)");
            string commandText = sb.ToString();
            var results = _context.ExecuteStoreQuery<SearchResultsMember>(commandText, queryParams);
            return results.ToList();
        }
