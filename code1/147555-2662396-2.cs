    // Contravariance
    interface IGobbler<in T> {
        void gobble(T t);
    }
    // Since a QuadrupedGobbler can gobble any four-footed
    // creature, it is OK to treat it as a donkey gobbler.
    IGobbler<Donkey> dg = new QuadrupedGobbler();
    dg.gobble(MyDonkey());
    // Covariance
    interface ISpewer<out T> {
        T spew();
    }
    // A MouseSpewer obviously spews rodents (all mice are
    // rodents), so we can treat it as a rodent spewer.
    ISpewer<Rodent> rs = new MouseSpewer();
    Rodent r = rs.spew();
