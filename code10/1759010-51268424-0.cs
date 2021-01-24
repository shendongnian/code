    [Flags]
    internal enum fModes
    {
       /// <summary>
       /// When used, the DocumentProperties function returns the number
       /// of bytes required by the printer driver's DEVMODE data structure.
       /// </summary>
       DM_SIZEOF = 0,
    
       /// <summary>
       /// <see cref="DM_OUT_DEFAULT"/>
       /// </summary>
       DM_UPDATE = 1,
    
       /// <summary>
       /// <see cref="DM_OUT_BUFFER"/>
       /// </summary>
       DM_COPY = 2,
    
       /// <summary>
       /// <see cref="DM_IN_PROMPT"/>
       /// </summary>
       DM_PROMPT = 4,
    
       /// <summary>
       /// <see cref="DM_IN_BUFFER"/>
       /// </summary>
       DM_MODIFY = 8,
    
       /// <summary>
       /// No description available.
       /// </summary>
       DM_OUT_DEFAULT = DM_UPDATE,
    
       /// <summary>
       /// Output value. The function writes the printer driver's current print settings,
       /// including private data, to the DEVMODE data structure specified by the 
       /// pDevModeOutput parameter. The caller must allocate a buffer sufficiently large
       /// to contain the information. 
       /// If the bit DM_OUT_BUFFER sets is clear, the pDevModeOutput parameter can be NULL.
       /// This value is also defined as <see cref="DM_COPY"/>.
       /// </summary>
       DM_OUT_BUFFER = DM_COPY,
    
       /// <summary>
       /// Input value. The function presents the printer driver's Print Setup property
       /// sheet and then changes the settings in the printer's DEVMODE data structure
       /// to those values specified by the user. 
       /// This value is also defined as <see cref="DM_PROMPT"/>.
       /// </summary>
       DM_IN_PROMPT = DM_PROMPT,
    
       /// <summary>
       /// Input value. Before prompting, copying, or updating, the function merges 
       /// the printer driver's current print settings with the settings in the DEVMODE
       /// structure specified by the pDevModeInput parameter. 
       /// The function updates the structure only for those members specified by the
       /// DEVMODE structure's dmFields member. 
       /// This value is also defined as <see cref="DM_MODIFY"/>. 
       /// In cases of conflict during the merge, the settings in the DEVMODE structure 
       /// specified by pDevModeInput override the printer driver's current print settings.
       /// </summary>
       DM_IN_BUFFER = DM_MODIFY,
    }
