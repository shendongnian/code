    public static class MedicationTagsExtensions {
      public static String Description(this MedicationTags value) {
        return string.Join(", ",
          (value.HasFlag(MedicationTags.Narcotic) ? "" : "non-") + "Narcotic",
          (value.HasFlag(MedicationTags.Psychotropic) ? "" : "non-") + "Psychotropic"
        );
      }
    }
