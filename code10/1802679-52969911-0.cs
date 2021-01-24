       int counter = 1;
            var parameterList = new List<SqlParameter>();
            SqlCommand command = new SqlCommand();
            string sqlCommand = $"UPDATE WITestData SET " +
                "Width01 = {widthParameter}, Angle01 = {angleParameter}, Comment01 = {commentParameter}, " +
                "Width02 = {widthParameter}, Angle02 = {angleParameter}, Comment02 = {commentParameter}, " +
                "Width03 = {widthParameter}, Angle03 = {angleParameter}, Comment03 = {commentParameter}, " +
                "Width04 = {widthParameter}, Angle04 = {angleParameter}, Comment04 = {commentParameter}, " +
                "Width05 = {widthParameter}, Angle05 = {angleParameter}, Comment05 = {commentParameter}, " +
                "Width06 = {widthParameter}, Angle06 = {angleParameter}, Comment06 = {commentParameter}, " +
                "Width07 = {widthParameter}, Angle07 = {angleParameter}, Comment07 = {commentParameter}, " +
                "Width08 = {widthParameter}, Angle08 = {angleParameter}, Comment08 = {commentParameter}, " +
                "Width09 = {widthParameter}, Angle09 = {angleParameter}, Comment09 = {commentParameter}, " +
                "Width10 = {widthParameter}, Angle10 = {angleParameter}, Comment10 = {commentParameter} " +
                "WHERE ReportNumber = @reportNumber";
            var parameters = new object[31];
            for (int i = 0; i < WITestData.WIData.Length; i++)
            {
                //input Parameters into sqlCommand
                string widthParameter = $"@width{(counter < 10 ? counter.ToString("D2") : counter.ToString() )}";
                string angleParameter = $"@angle{(counter < 10 ? counter.ToString("D2") : counter.ToString())}";
                string commentParameter = $"@comment{(counter < 10 ? counter.ToString("D2") : counter.ToString())}";
                using (command)
                {
                    parameterList.Add(new SqlParameter(widthParameter, WITestData.WIData[i].Width));
                    parameterList.Add(new SqlParameter(angleParameter, WITestData.WIData[i].Angle));
                    parameterList.Add(new SqlParameter(commentParameter, WITestData.WIData[i].Comment));
                    command.Parameters.Clear();
                }
                parameters[3 * i] = WITestData.WIData[i].Width;
                parameters[3 * i + 1] = WITestData.WIData[i].Angle;
                parameters[3 * i + 2] = WITestData.WIData[i].Comment;
                counter++;
            }
