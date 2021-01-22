                //on master ... CREATE
                using (var cnn = new SqlConnection(MASTER))
                {
                    cnn.Open();
                    var createDbCmd = new SqlCommand(string.Format("create database [{0}]", db), cnn).ExecuteNonQuery();
                    cnn.Close();
                }
                using (var cnn = new SqlConnection(tempDB))
                {
                    cnn.Open();
                    var createTbl = new SqlCommand(string.Format("create table t (t int )"), cnn).ExecuteNonQuery();
                    var dropTbl = new SqlCommand(string.Format("drop table t"), cnn).ExecuteNonQuery();
                    //Do additional stuf
                    var userMaster = new SqlCommand(string.Format("use master"), cnn).ExecuteNonQuery();
                    cnn.Close();
                }
                //on master ... CREATE
                using (var cnn = new SqlConnection(MASTER))
                {
                    cnn.Open();
                    var dropDbCmd = new SqlCommand(string.Format("drop database [{0}]", db), cnn).ExecuteNonQuery();
                    cnn.Close();
                }
