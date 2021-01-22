    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;
    using System.Text;
    using System.IO;
    using Model;
    public class MyScript : IScriptRunner
    {
        private string m_scripts_directory = "Scripts";
        
        /// <summary>
        /// Run implements IScriptRunner interface
        /// to be invoked by QuranCode application
        /// with Client, current Selection.Verses, and extra data
        /// </summary>
        /// <param name="args">any number and type of arguments</param>
        /// <returns>return any type</returns>
        public object Run(object[] args)
        {
            try
            {
                if (args.Length == 3)   // ScriptMethod(Client, List<Verse>, string)
                {
                    Client client = args[0] as Client;
                    List<Verse> verses = args[1] as List<Verse>;
                    string extra = args[2].ToString();
                    if ((client != null) && (verses != null))
                    {
                        return MyMethod(client, verses, extra);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
                return null;
            }
        }
        /// <summary>
        /// Write your C# script insde this method.
        /// Don't change its name or parameters
        /// </summary>
        /// <param name="client">Client object holding a reference to the currently selected Book object in TextMode (eg Simplified29)</param>
        /// <param name="verses">Verses of the currently selected Chapter/Page/Station/Part/Group/Quarter/Bowing part of the Book</param>
        /// <param name="extra">any user parameter in the TextBox next to the EXE button (ex Frequency, LettersToJump, DigitSum target, etc)</param>
        /// <returns>true to disply back in QuranCode matching verses. false to keep script window open</returns>
        private long MyMethod(Client client, List<Verse> verses, string extra)
        {
            if (client == null) return false;
            if (verses == null) return false;
            if (verses.Count == 0) return false;
            int target;
            if (extra == "")
            {
                target = 0;
            }
            else
            {
                if (!int.TryParse(extra, out target))
                {
                    return false;
                }
            }
            try
            {
                long total_value = 0L;
                foreach (Verse verse in verses)
                {
                    total_value += Client.CalculateValue(verse.Text);
                }
                return total_value;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName);
                return 0L;
            }
        }
    }
