       0 30  886: SEQUENCE {
       4 30  606:   SEQUENCE {
       8 A0    3:     [0] {
      10 02    1:       INTEGER 2
                :       }
      13 02   16:     INTEGER
                :       6E F0 A9 78 7D 3C D4 05 4E 90 13 DC 9D 34 77 2C
      31 30   13:     SEQUENCE {
      33 06    9:       OBJECT IDENTIFIER
                :         sha1withRSAEncryption (1 2 840 113549 1 1 5)
      44 05    0:       NULL
                :       }
      46 30   77:     SEQUENCE {
      48 31   11:       SET {
      50 30    9:         SEQUENCE {
      52 06    3:           OBJECT IDENTIFIER countryName (2 5 4 6)
      57 13    2:           PrintableString 'NZ'
                :           }
                :         }
      61 31   40:       SET {
      63 30   38:         SEQUENCE {
      65 06    3:           OBJECT IDENTIFIER organizationName (2 5 4 10)
      70 13   31:           PrintableString 'First Mortgage Services Limited'
                :           }
                :         }
     103 31   20:       SET {
     105 30   18:         SEQUENCE {
     107 06    3:           OBJECT IDENTIFIER commonName (2 5 4 3)
     112 13   11:           PrintableString 'FMS Root CA'
                :           }
                :         }
                :       }
     125 30   30:     SEQUENCE {
     127 17   13:       UTCTime '091222000000Z'
     142 17   13:       UTCTime '101222235959Z'
                :       }
     157 30   98:     SEQUENCE {
     159 31   36:       SET {
     161 30   34:         SEQUENCE {
     163 06    3:           OBJECT IDENTIFIER organizationName (2 5 4 10)
     168 14   27:           TeletexString 'First Mortgage Services Ltd'
                :           }
                :         }
     197 31   31:       SET {
     199 30   29:         SEQUENCE {
     201 06    3:           OBJECT IDENTIFIER organizationalUnitName (2 5 4 11)
     206 14   22:           TeletexString 'For Test Purposes Only'
                :           }
                :         }
     230 31   25:       SET {
     232 30   23:         SEQUENCE {
     234 06    3:           OBJECT IDENTIFIER commonName (2 5 4 3)
     239 14   16:           TeletexString 'Daniel Mapletoft'
                :           }
                :         }
                :       }
     257 30  159:     SEQUENCE {
     260 30   13:       SEQUENCE {
     262 06    9:         OBJECT IDENTIFIER rsaEncryption (1 2 840 113549 1 1 1)
     273 05    0:         NULL
                :         }
     275 03  141:       BIT STRING 0 unused bits, encapsulates {
     279 30  137:           SEQUENCE {
     282 02  129:             INTEGER
                :               00 CD 08 AE 3E E3 5A E4 5E 50 28 29 5E 65 05 DA
                :               1A E1 9C 50 44 4A F0 06 AA 75 1A 8F F0 75 4C AA
                :               47 4B D5 8F 04 B5 CE 98 C5 0D 99 54 36 E9 EF 2E
                :               7D CD DF FA 46 B2 7D 76 E5 74 19 AD 3E F0 52 52
                :               C7 F8 86 E6 78 32 90 EB 2F 12 3F 7A 31 4B 15 E9
                :               2A 9D 75 91 EA 31 9F 4E 98 A6 06 81 DD 98 1B 1A
                :               DB FE 1F 2E BD 2E 32 60 5A 54 7C 0E 48 6A AB 6C
                :               C6 F6 E2 F2 FD 4A BE 5A BD E0 DF 0C 21 B6 4C 9E
                :                       [ Another 1 bytes skipped ]
     414 02    3:             INTEGER 65537
                :             }
                :           }
                :       }
     419 A3  192:     [3] {
     422 30  189:       SEQUENCE {
     425 30    9:         SEQUENCE {
     427 06    3:           OBJECT IDENTIFIER basicConstraints (2 5 29 19)
     432 04    2:           OCTET STRING, encapsulates {
     434 30    0:               SEQUENCE {}
                :               }
                :           }
     436 30   14:         SEQUENCE {
     438 06    3:           OBJECT IDENTIFIER keyUsage (2 5 29 15)
     443 01    1:           BOOLEAN TRUE
     446 04    4:           OCTET STRING, encapsulates {
     448 03    2:               BIT STRING 5 unused bits
                :                 '101'B
                :               }
                :           }
     452 30   96:         SEQUENCE {
     454 06    3:           OBJECT IDENTIFIER cRLDistributionPoints (2 5 29 31)
     459 01    1:           BOOLEAN TRUE
     462 04   86:           OCTET STRING, encapsulates {
     464 30   84:               SEQUENCE {
     466 30   82:                 SEQUENCE {
     468 A0   80:                   [0] {
     470 A0   78:                     [0] {
     472 86   76:                       [6]
                :                   'http://onsitecrl.verisign.com/FirstMortgageServi'
                :                   'cesLtdPropellc/LatestCRL.crl'
                :                       }
                :                     }
                :                   }
                :                 }
                :               }
                :           }
     550 30   31:         SEQUENCE {
     552 06    3:           OBJECT IDENTIFIER authorityKeyIdentifier (2 5 29 35)
     557 04   24:           OCTET STRING, encapsulates {
     559 30   22:               SEQUENCE {
     561 80   20:                 [0]
                :                   8B 2A 2C 58 39 03 B2 61 9F 16 E7 3D 3D F1 70 4D
                :                   B1 F3 D4 E2
                :                 }
                :               }
                :           }
     583 30   29:         SEQUENCE {
     585 06    3:           OBJECT IDENTIFIER subjectKeyIdentifier (2 5 29 14)
     590 04   22:           OCTET STRING, encapsulates {
     592 04   20:               OCTET STRING
                :                 3E 91 DB A0 9C B4 A1 CB 68 CC 70 D0 0A 29 D6 BF
                :                 4E 68 10 AB
                :               }
                :           }
                :         }
                :       }
                :     }
     614 30   13:   SEQUENCE {
     616 06    9:     OBJECT IDENTIFIER
                :       sha1withRSAEncryption (1 2 840 113549 1 1 5)
     627 05    0:     NULL
                :     }
     629 03  257:   BIT STRING 0 unused bits
                :     3E C3 A3 F3 5F 3E 29 37 4D 33 E3 F5 F2 89 42 78
                :     AC CD 59 14 E9 CC FF 20 8F 98 34 7B F0 F4 D2 96
                :     EC 58 53 61 E4 3E D0 02 CF FF 30 C8 77 D0 6F 94
                :     37 72 3C B7 90 6E 38 10 59 8C F8 06 B0 61 55 65
                :     58 96 30 7B 9A 58 FF DB 15 7C FA F9 1F 64 5E DC
                :     E8 63 EE EE 90 B1 18 3C 6A 11 62 73 91 CF DE DB
                :     34 F5 67 4F C9 89 77 5C 36 71 FC 11 27 07 C5 76
                :     BB 79 B8 8E 19 E8 E2 5B D7 A5 23 BA D8 19 7C 74
                :             [ Another 128 bytes skipped ]
                :   }
