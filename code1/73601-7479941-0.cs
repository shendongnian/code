    public class ToolTipHelper
    {
        private readonly Dictionary<string, ToolTip> tooltips;
        /// <summary>
        /// Constructor
        /// </summary>
        public ToolTipHelper()
        {
            this.tooltips = new Dictionary<string, ToolTip>();
        }
        /// <summary>
        /// Key a tooltip by its control name
        /// </summary>
        /// <param name="controlName"></param>
        /// <returns></returns>
        public ToolTip GetControlToolTip(string controlName)
        {
            if (tooltips.ContainsKey(controlName))
            {
                return tooltips[controlName];
            }
            else
            {
                ToolTip tt = new ToolTip();
                tooltips.Add(controlName, tt);
                return tt;
            }
        }
    }
