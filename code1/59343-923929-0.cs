        void insertMediaTags(List<string> tags, long mediaId)
        {
            foreach(string tag in tags)
            {
                long tagId;
                command.CommandText = "SELECT tagid FROM tag_name WHERE title=@title;";
                command.Parameters.Add("@title", DbType.String).Value = tag;
                object o = command.ExecuteScalar();
                if (o == null)
                {
                    command.CommandText =
                        "INSERT OR IGNORE INTO tag_name(title) VALUES(@title); " +
                        "SELECT last_insert_rowid() AS RecordID;";
                    command.Parameters.Add("@title", DbType.String).Value = tag;
                    tagId = (long)command.ExecuteScalar();
                }
                else
                    tagId = (long)o;
                command.CommandText =
                    "INSERT INTO media_tags(media_id, tagid) " +
                    "VALUES(@media_id, @tagid);";
                command.Parameters.Add("@media_id", DbType.Int32).Value = mediaId;
                command.Parameters.Add("@tagid", DbType.Int64).Value = tagId;
                command.ExecuteNonQuery();
            }
        }
