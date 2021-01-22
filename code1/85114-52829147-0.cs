    [Harmony.HarmonyPatch(typeof(System.Windows.Forms.PrintPreviewControl))]
    [Harmony.HarmonyPatch("ComputePreview")]
    class PrintPreviewControlPatch
    {
        static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
        {
            var cis = new List<CodeInstruction>(instructions);
            // the codes 26 to 28 deal with creating the
            // progress reporting preview generator that
            // we don't want. We replace them with No-Operation
            // code instructions. 
            cis[26] = new CodeInstruction(OpCodes.Nop);
            cis[27] = new CodeInstruction(OpCodes.Nop);
            cis[28] = new CodeInstruction(OpCodes.Nop);
            return cis;
        }
    }
