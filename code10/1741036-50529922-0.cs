    class Program {
        static void Main(string[] args) {
            var now = DateTime.Now; // normal now
            var harmony = HarmonyInstance.Create("test");
            // patch
            harmony.PatchAll(Assembly.GetExecutingAssembly());
            // now + 100 years
            var newNow = DateTime.Now;
        }
        // we are rewriting method get_Now, which is a getter of property Now
        // of type DateTime
        [HarmonyPatch(typeof(DateTime), "get_Now")]
        class Patch {
            // this method runs after original one
            // __result stores value produced by original
            static DateTime Postfix(DateTime __result) {
                // add 100 years to it
                return __result.AddYears(100);
            }
        }
    }
