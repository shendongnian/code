private void InitFlashMovie(AxShockwaveFlash flashObj, byte[] swfFile)
{
    using (MemoryStream stm = new MemoryStream())
    {
        using (BinaryWriter writer = new BinaryWriter(stm))
        {
            /* Write length of stream for AxHost.State */
            writer.Write(8 + swfFile.Length);
            /* Write Flash magic 'fUfU' */
            writer.Write(0x55665566);
            /* Length of swf file */
            writer.Write(swfFile.Length);                    
            writer.Write(swfFile);
            stm.Seek(0, SeekOrigin.Begin);
            /* 1 == IPeristStreamInit */
            flashObj.OcxState = new AxHost.State(stm, 1, false, null);
        }
    }
}
