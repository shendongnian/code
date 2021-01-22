    class FighterBase extends ShipBase {
        //... implementation of whatever kind of things fighters have in common
        //... a protected intializer to call by subclasses    
    }
    final class Fighter extends FighterBase {
        //... public initializer possibly just forwarding to protected initializer
    }
    final class EliteFighter2000 extends FighterBase {
        //... here goes all the 'elite' stuff
    }
