    public sealed class Player {
      public static explicit operator PlayerDTO(Player p) {
        PlayerDTO dto;
        // construct
        return dto;
      }
    }
    public sealed class PlayerDTO {
      public static explicit operator Player(PlayerDTO dto) {
        Player p;
        // construct
        return p;
      }
    }
