    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    
    namespace Logger
    {
    	/// <summary>
    	/// A circular buffer style logging class which stores N items for display in a Rich Text Box.
    	/// </summary>
    	public class Logger
    	{
    		private readonly Queue<LogEntry> _log;
    		private uint _entryNumber;
    		private readonly uint _maxEntries;
    		private readonly object _logLock = new object();
    		private readonly Color _defaultColor = Color.White;
    
    		private class LogEntry
    		{
    			public uint EntryId;
    			public DateTime EntryTimeStamp;
    			public string EntryText;
    			public Color EntryColor;
    		}
    
    		private struct ColorTableItem
    		{
    			public uint Index;
    			public string RichColor;
    		}
    
    		/// <summary>
    		/// Create an instance of the Logger class which stores <paramref name="maximumEntries"/> log entries.
    		/// </summary>
    		public Logger(uint maximumEntries)
    		{
    			_log = new Queue<LogEntry>();
    			_maxEntries = maximumEntries;
    		}
    
    		/// <summary>
    		/// Retrieve the contents of the log as rich text, suitable for populating a <see cref="System.Windows.Forms.RichTextBox.Rtf"/> property.
    		/// </summary>
    		/// <param name="includeEntryNumbers">Option to prepend line numbers to each entry.</param>
    		public string GetLogAsRichText(bool includeEntryNumbers)
    		{
    			lock (_logLock)
    			{
    				var sb = new StringBuilder();
    
    				var uniqueColors = BuildRichTextColorTable();
    				sb.AppendLine($@"{{\rtf1{{\colortbl;{ string.Join("", uniqueColors.Select(d => d.Value.RichColor)) }}}");
    
    				foreach (var entry in _log)
    				{
    					if (includeEntryNumbers)
    						sb.Append($"\\cf1 { entry.EntryId }. ");
    
    					sb.Append($"\\cf1 { entry.EntryTimeStamp.ToShortDateString() } { entry.EntryTimeStamp.ToShortTimeString() }: ");
    
    					var richColor = $"\\cf{ uniqueColors[entry.EntryColor].Index + 1 }";
    					sb.Append($"{ richColor } { entry.EntryText }\\par").AppendLine();
    				}
    				return sb.ToString();
    			}
    		}
    
    		/// <summary>
    		/// Adds <paramref name="text"/> as a log entry.
    		/// </summary>
    		public void AddToLog(string text)
    		{
    			AddToLog(text, _defaultColor);
    		}
    
    		/// <summary>
    		/// Adds <paramref name="text"/> as a log entry, and specifies a color to display it in.
    		/// </summary>
    		public void AddToLog(string text, Color entryColor)
    		{
    			lock (_log)
    			{
    				if (_entryNumber >= uint.MaxValue)
    					_entryNumber = 0;
    				_entryNumber++;
    				var logEntry = new LogEntry { EntryId = _entryNumber, EntryTimeStamp = DateTime.Now, EntryText = text, EntryColor = entryColor };
    				_log.Enqueue(logEntry);
    
    				while (_log.Count > _maxEntries)
    					_log.Dequeue();
    			}
    		}
    
    		/// <summary>
    		/// Clears the entire log.
    		/// </summary>
    		public void Clear()
    		{
    			lock (_logLock)
    			{
    				_log.Clear();
    			}
    		}
    
    		private Dictionary<Color, ColorTableItem> BuildRichTextColorTable()
    		{
    			var uniqueColors = new Dictionary<Color, ColorTableItem>();
    			var index = 0u;
    
    			uniqueColors.Add(_defaultColor, new ColorTableItem() { Index = index++, RichColor = ColorToRichColorString(_defaultColor) });
    
    			foreach (var c in _log.Select(l => l.EntryColor).Distinct().Where(c => c != _defaultColor))
    				uniqueColors.Add(c, new ColorTableItem() { Index = index++, RichColor = ColorToRichColorString(c) });
    
    			return uniqueColors;
    		}
    
    		private string ColorToRichColorString(Color c)
    		{
    			return $"\\red{c.R}\\green{c.G}\\blue{c.B};";
    		}
    	}
    }
