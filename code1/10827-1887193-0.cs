        private static readonly Oid oidInstance = new Oid();
        private static void AddSubjectString(IAsn1Node parent, string oid, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                parent.AddChild(AddString(new Asn1Node
                {
                    Tag = Asn1Tag.SET | Asn1TagClasses.CONSTRUCTED
                },
                                          oid, value));
            }
        }
        private static Asn1Node AddString(Asn1Node parent, string name, string value)
        {
            var childNode = new Asn1Node
            {
                Tag = Asn1Tag.SEQUENCE | Asn1TagClasses.CONSTRUCTED
            };
            parent.AddChild(childNode);
            var nameNode = new Asn1Node
            {
                Tag = Asn1Tag.OBJECT_IDENTIFIER,
                Data = oidInstance.Encode(name)
            };
            childNode.AddChild(nameNode);
            var valueNode = new Asn1Node();
            if (value == null)
            {
                valueNode.Tag = Asn1Tag.TAG_NULL;
            }
            else
            {
                valueNode.Tag = Asn1Tag.PRINTABLE_STRING;
                valueNode.Data = Encoding.ASCII.GetBytes(value);
            }
            childNode.AddChild(valueNode);
            return parent;
        }
        public static void GenerateCsr(RSACryptoServiceProvider keyPair, Certificates.Subject subject, Stream output)
        {
            var rootNode = new Asn1Node
            {
                Tag = Asn1Tag.SEQUENCE | Asn1TagClasses.CONSTRUCTED
            };
            var topSequenceNode = new Asn1Node
            {
                Tag = Asn1Tag.SEQUENCE | Asn1TagClasses.CONSTRUCTED
            };
            rootNode.AddChild(topSequenceNode);
            var versionNode = new Asn1Node
            {
                Tag = Asn1Tag.INTEGER,
                Data = new byte[] { 0 }
            };
            topSequenceNode.AddChild(versionNode);
            var stringSequenceNode = new Asn1Node
            {
                Tag = Asn1Tag.SEQUENCE | Asn1TagClasses.CONSTRUCTED
            };
            topSequenceNode.AddChild(stringSequenceNode);
            AddSubjectString(stringSequenceNode, Oid.OID_COMMON_NAME, subject.CommonName);
            AddSubjectString(stringSequenceNode, Oid.OID_ORGANIZATIONAL_UNIT, subject.OrganisationalUnit);
            AddSubjectString(stringSequenceNode, Oid.OID_LOCALITY_NAME, subject.City);
            AddSubjectString(stringSequenceNode, Oid.OID_COUNTRY_NAME, subject.Country);
            AddSubjectString(stringSequenceNode, Oid.OID_PROVINCE_NAME, subject.Province);
            AddSubjectString(stringSequenceNode, Oid.OID_ORGANIZATION, subject.Organisation);
            AddSubjectString(stringSequenceNode, Oid.OID_EMAIL_ADDRESS, subject.EmailAddress);
            var rsaNode = new Asn1Node
            {
                Tag = Asn1Tag.SEQUENCE | Asn1TagClasses.CONSTRUCTED
            };
            topSequenceNode.AddChild(AddString(rsaNode, Oid.OID_RSA_ENCRYPTION, null));
            var publicKeyNode = new Asn1Node
            {
                Tag = Asn1Tag.BIT_STRING
            };
            rsaNode.AddChild(publicKeyNode);
            var publicKeySequenceNode = new Asn1Node
            {
                Tag = Asn1Tag.SEQUENCE | Asn1TagClasses.CONSTRUCTED
            };
            publicKeyNode.AddChild(publicKeySequenceNode);
            var publicKeyInfo = keyPair.ExportParameters(false);
            publicKeySequenceNode.AddChild(new Asn1Node
            {
                Tag = Asn1Tag.INTEGER,
                Data = publicKeyInfo.Modulus
            });
            publicKeySequenceNode.AddChild(new Asn1Node
            {
                Tag = Asn1Tag.INTEGER,
                Data = publicKeyInfo.Exponent
            });
            topSequenceNode.AddChild(new Asn1Node
            {
                Tag = Asn1TagClasses.CONTEXT_SPECIFIC | Asn1TagClasses.CONSTRUCTED
            });
            byte[] signature;
            using (var data = new MemoryStream(1024))
            {
                topSequenceNode.SaveData(data);
                signature = keyPair.SignData(data.GetBuffer(), 0, (int)data.Length, new SHA1CryptoServiceProvider());
            }
            AddString(rootNode, Oid.OID_SHA1_WITH_RSA, null);
            rootNode.AddChild(new Asn1Node
            {
                Tag = Asn1Tag.BIT_STRING,
                Data = signature
            });
            var csrOutput = new StreamWriter(output);
            csrOutput.WriteLine("-----BEGIN CERTIFICATE REQUEST-----");
            using (var data = new MemoryStream(1024))
            {
                rootNode.SaveData(data);
                var base64Data = Convert.ToBase64String(data.GetBuffer(), 0, (int)data.Length,
                                                        Base64FormattingOptions.InsertLineBreaks);
                csrOutput.WriteLine(base64Data);
            }
            csrOutput.WriteLine("-----END CERTIFICATE REQUEST-----");
            csrOutput.Flush();
        }
