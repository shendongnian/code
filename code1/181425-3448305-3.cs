    class ShipBase {//in Java you might wanna put the 'abstract' keyword just infront
     //... implementation of some sort
     //... maybe a protected intializer to call by subclasses
     //... no public initializer, since class is abstract
    }
    final class Fighter extends ShipBase {
     //... public initializer specific to Fighter
     //... other custom behaviour
    }
    final class Bomber extends ShipBase {
     //... I guess, this is obvious
    }
