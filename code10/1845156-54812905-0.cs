    using System;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;
    namespace GenererScriptSQL
{
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private static void AddSqlCommand(StringBuilder sql, string[] columns, string[] types, string[] values)
        {
            sql.AppendLine("UPDATE Contact");
            sql.AppendLine("SET");
            //skip LoginId columns
            for (int i = 1; i < columns.Length; i++)
            {
                switch (types[i].Trim())
                {
                    case "int":
                        sql.Append($"   Contact.{columns[i].Trim()} = {values[i]}");
                        break;
                    default:
                        sql.Append($"   Contact.{columns[i].Trim()} = '{values[i]}'");
                        break;
                }
                if (columns.Length > 1 && i != columns.Length - 1)
                {
                    sql.Append(",");
                }
                sql.AppendLine();
            }
            sql.AppendLine();
            sql.AppendLine("WHERE");
            sql.AppendLine();
            sql.AppendLine($"   Contact.{columns[0].Trim()} = '{values[0]}'");
            sql.AppendLine();
        }
        private static StringBuilder GenerateSqlScript(string[] fileContent)
        {
            var sqlCommand = new StringBuilder();
            string[] types = fileContent[0].Split(';');
            string[] columns = fileContent[0].Split(';');
            //skip the first line(header)
            for (int i = 1; i < fileContent.Length; i++)
            {
                string[] values = fileContent[i].Split(';');
                if (values.Length >= 1)
                {
                    AddSqlCommand(sqlCommand, columns, types, values);
                }
            }
            return sqlCommand;
        }
        private void buttonCreateSqlFile_Click(object sender, EventArgs e)
        {
            try
            {
                if (IsFileSelected())
                {
                    string[] fileContent = File.ReadAllLines(textBoxFile.Text);
                    if (fileContent != null)
                    {
                        StringBuilder sqlCommand = GenerateSqlScript(fileContent);
                        if (!string.IsNullOrWhiteSpace(sqlCommand.ToString()))
                        {
                            WriteSqlFile(sqlCommand);
                        }
                    }
                    
                }
                else
                {
                    MessageBox.Show("Sélectionner le fichier de chargement.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void buttonSelectFile_Click(object sender, EventArgs e)
        {
            try
            {
                using (var fileBrowser = new OpenFileDialog())
                {
                    if (fileBrowser.ShowDialog() == DialogResult.OK)
                    {
                        textBoxFile.Text = fileBrowser.FileName;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private bool IsFileSelected()
        {
            return !string.IsNullOrWhiteSpace(textBoxFile.Text) && File.Exists(textBoxFile.Text);
        }
        private void WriteSqlFile(StringBuilder sqlCommand)
        {
            var fileInfo = new FileInfo(textBoxFile.Text);
            string BackupDate = fileInfo.Name + "_" + DateTime.Now.ToString("yyyy-MM-dd_HH-mm") + "_Update" + ".sql";
            string sqlFilePath = Path.Combine(fileInfo.Directory.FullName, BackupDate);
            if (File.Exists(sqlFilePath))
            {
                File.Delete(sqlFilePath);
            }
            File.WriteAllText(sqlFilePath, sqlCommand.ToString());
            MessageBox.Show($@" Le fichier sql a été générée! {sqlFilePath}");
        }
    }
