    using System.IO;
    using Org.BouncyCastle.Crypto;
    using Org.BouncyCastle.OpenSsl;
    
    namespace ImportRSAPrivateKeyPEM
    {
        class MainClass
        {
            readonly static string PEM_PRIV_KEY = @"-----BEGIN RSA PRIVATE KEY-----
    MIIJKQIBAAKCAgEA7drrGdj9TY6MZCm3kuCsXKVD2v5kUS38MCtA5PjGp72/A1IO
    izG51WjyvCkULjBBQzOr366TcO5HtMzmVlipDzIFJdeQN2Z1gY5oVqA04zGlEAf4
    vcgM0ygJLEbtcAYMZz/5Y5RgPqAnv3J3TiB82mbXURVg2PvHp7c+0Rl8vZmC4RIq
    +DDkxXfccOFh8eaY4VYfIZPHsZZeX6ih+6JbuReCKU7zVPUMspefOyaMNj+NFeVN
    XgKbtcerABpxE1ckWUsNVuw+GHBpJ0MCmBcfNYtMxZv8FZLdNziLsn0moN8RNC29
    PRa+Kmt4OPTA+YXBQt8Q4f8K/OHDlKc80XdcrfNG4SMLaLJpdmbVRumDEmHx2dV+
    6AHR+SwjkBRdkdWIg0JSmmraEcrKvgXz+ZkVfXbTWAbB5+Mq4ZT+BF0cRRoag13K
    U0uaAdhM99zn2Qshdam1Vj++rfTAlaZx+xvx0C92gkC7qC4SmJlnGGisAN8NzYKo
    DXX5cV/R5x3w5I98fXBIw0y1NNBlUuEd8OT9wDwvcvA4Y+vpjUPprXScgJcTL72i
    x0/BIRDNP3zfBhmKG6XR1MW9dO38pWbn/iS6I2i2jzqnL+mYKQQ35sjvonkkrOpi
    amh7V4T1e+H3n8LWBSPSgkKUk936+LouxLzJ4vEeOEg2C/V4T8obrdlCaqMCAwEA
    AQKCAgApocrKwGc9vvilw4OFKtwgbzDcUPCgIOtmRvvZ2A11aMnZO/CdvntndjIe
    axZEK2AQ8idgRH88IgjdBYw/is80gK3T/NIaUE26+oEawHnhVlws3ShVl4FfKD/K
    xzNiCzz6iYEOQ/dAnum2IcPuIdOYqq1/XL2R3SgKHBHbqZli2k7FNFffDzfLtHoa
    K+jn3VPfBSL3zpUCaW5lUe/gSn/BevLmZhJDSY0KaW2OfeXGzQLV1Ufgb5Zvj95H
    a1llaDhNhMx17W3E+0/8dkcq9ckZpyMt52qNICKmOriA6lTrjX/GYUchPSzV4e+u
    EHECe73jBYY/+FMlBiMkjs0fYMQQvAOMF5g/A7pv/dfxiaiMIC84wKRbh8GGfKh/
    Ropwa84F9no6fUF9jFhDxzDjxIzsrJOF0C/nPl2vKb3qSkhhQMQSAJhLmyMJ/BHo
    CUCWDkE9cRQ+YYrXYycfsSOvr5j4XmztSBm0JgqZm2JMfMR21kw9hTzef99EHEFx
    N8fLCz6jcqwycrKqZo7+oiWQrCnARurQT8uauCxpdVnsjZCpgIs9HyybBg4YtUCu
    hoQzUzPHU3dUAUhEPVweUfM8qDjCekMLXDAjXKtoWwA3A3m6Jmjy64dJIfso3CLY
    KGauIukTGOl8mu4ZDpEiPVE4NLao6S22mITgLnfGnb3zRU4w0QKCAQEA+b8Y8S13
    vvMpUiwGGC9bdPTnyVTpt3RSrYBjojStOf1yfnrbUVomEt2qEYCbq6a3eBfSbA6w
    whpxPsZvrjQudUKQH9VqCE18q0sUJzOVu/kO+KR2P+8EAFPDoA+KXc1pxWBADoIs
    mnVfM8xjI0BR6Dhyk6GXagUFdS7dS8PHEy8pRa1weZQ67IpYpl8etxfCtGY8W0p9
    hXXn3adt4da9ga8XAZFdfn0e/NM+b05btHqotC/w+nRDw283ymB43Cfq3IPAVWFe
    Jv/2A9eUsyEHhL7SxWSEOyYq+gFGLpnb0S/Sy91wQtiL54vD5wCadec3STs3dnsC
    Yo9pTxaPE103ewKCAQEA88+Yoj+h0KMkesN3ozIQq0Gd5IEGvwQs7dgWzCYarTVf
    cbBm76IXu0cf+UGZv/rDjSJC56IzN7e9GSfYs5QHteL64ce8nnM3JxLNs5eq9B6c
    VcBMwWhQkyIbJwD2hxfs7u8wEvVjNkRjMoAKvo8ne2r5Mjxc5qsFVdYLd64RTK8y
    Qn52+ximTq3CNdTI/Z3w1uA9SR6sff5PjPhymgsIcM7NZ7Fmi12cddQdUwtkIaNP
    hWblJE2N+CFJUn2wArWOPrlYKcZ3KCSHZVOIWFca9nidDUOaZ4eAsbP/LKQp/LEF
    MkAn7Wsy3Rmlj6NuGabNUEzhexW9sBn/BJH8WrIc+QKCAQEAgbQRTBAFBJJcf2SF
    tcHCibc3OYRz7ObomVr4Y6Ff5aIO+Ejt5g4ff+THElfsgPUQi7ozehMXEXeSILwF
    /D71ccij+SRo8O7tNDjFuqY7uWfbsp4XG5USSuk1y8bGYXjw2aTnH6HTcFRMoSYg
    xon8/9FxD+L4NANvljBElbiThw8TLDCrHTkycO5Yo+76kLQyVmZSKkdBcTKOvLrb
    glJ4EQXRuOq515s7oKpE3qGfVtftDcdoK2p+Vt1H6D66BfxlKSjzlmP+9dow9kXb
    4DvjH7nK1OEjG2TzJOvMex9E3hssKtxSFSVJY3NexnW1wk3WlJ3AbDPuRSmd04kv
    vSrISQKCAQEAlZ5+EoNuL/UN+/BcSN/+brozxPiRRUOwtrz3MIzprgWk7sXMRZ55
    Zco+Ct6BFdkzjDbMTA2z1KuC9h8H0xwypyIFx+ylCa+21tmpNl8K4Aiw88aw07fK
    SqCRfRwQLdM26WILZHcGTVUmcuU0ssBzAEAjcPquIDgva/+Qxf8iSqbw9vFY3rq/
    xGTJW/Oa7FiyZYry0R5ryF36P45v9axzn5apYsrxHPFzhLOI01+YMTRhJoKAeAjH
    6M+0iVTsYJ0+D6v6OJi8ovvXwwzCDURXHY3jAzLLXGFBTswg+io8Qf/4KmBIoGA6
    tIh6m201sbQ1JuQnMzuiTqGFaC6WaKoJMQKCAQBkA5UMKy0Yp3Pec+cWJMWAEdEm
    mqScwgrJJnhss5MYUUk4RsypMgdLCn56K1KC3fHuirYZ4xtGt7UlAkNUy2IU1/aP
    m+V7w3vRVnDxF0bd/YR6hYlZu8p8jK4noigZJ9DFJO310Ln+jdDq/YZ3m7ntax3e
    bQPvPK3Yn7U0vCocT7fQ44Pquxp9qlIApomH5GJ42kcIrCJ+O2YYx6gWgO2GuGCI
    Q/g2WdDdXwAfxCMxSkAKi4q3BV6KvkdbbDq/8aMy5o71ePonDm84Ipom9PUDxqwG
    dbrB6/PfYXo81POZPbCbeir31AjycePSSBk4sjb7AES+18MvXy3sgn2dHesF
    -----END RSA PRIVATE KEY-----";
    
    
            public static void Main(string[] args)
            {
                var rdr = new StringReader(PEM_PRIV_KEY);
                var pemReader = new PemReader(rdr);
                AsymmetricCipherKeyPair pemObject = (Org.BouncyCastle.Crypto.AsymmetricCipherKeyPair)pemReader.ReadObject();
    
            }
        }
    }
