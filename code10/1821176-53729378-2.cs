    // Could be static, but I hate static. Don't use static.
    public class BroncoFactory
    {
         private List<BroncoClass> trackedObjects
         public BroncoClass New()
         {
             var newInstance = new BroncoClass();
             trackedObjects.Add(newInstance)
         }
         // Don't forget to call this or you'll leak!
         public void Free(BroncoClass instance)
         {
              trackedObjects.Remove(instance);
         }
         public bool ExistsWithNPC(NPC test)
         {
             return trackedObjects.Any(o => o.npc == test);
         }
    }
