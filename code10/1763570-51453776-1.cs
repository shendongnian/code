        String query = "delete from dbmahasiswa where NIM=@NIM AND Password=@Password";
        class_Mahasiswa cm = new class_Mahasiswa();
        try
        {
            connect.Open();
            MySqlCommand cmd = new MySqlCommand(query, connect);
            cmd.Parameters.AddWithValue("@NIM", nim);
            cmd.Parameters.AddWithValue("@Password", pass);
            int rows = cmd.ExecuteNonQuery();
            if (count > 0)
            {
                System.Windows.Forms.MessageBox.Show("sukses!", "Status");
                return true;
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("akun tidak ditemukan", "Status");
                return false;
            }
        }
        catch (Exception e)
        {
            System.Windows.Forms.MessageBox.Show(e.Message, "Warning");
            return false;
        }
        finally
        {
            connect.Close();
        }
    }
